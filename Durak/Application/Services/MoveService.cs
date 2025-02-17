using Durak.Application.Interfaces;
using Durak.Contracts.Responses;
using Durak.Domain.Entities;
using Durak.Domain.Enums;
using Durak.Infrastructure;

namespace Durak.Application.Services;

public class MoveService(ApplicationDbContext context) : IMoveService
{
    //  private static List<long> _firstPlayerHand = new();
    // private static List<long> _secondPlayerHand = new();

    private List<long> _movedCardIds = new();
    private static List<long> _beatenCardIds = new();

    private static bool _isBeaten;
    private static bool _isTaken;

    public static int MoveCard;

    private static HashSet<long>? _firstPlayerCards;
    private static HashSet<long>? _secondPlayerCards;

    public static int MoveIdCounter = 0;

    public MoveResponse CreateMoveHistoryFirstPlayer(ActionTypeEnum actionTypeEnum, long playerId,
        bool isTaken, int moveCard, bool isBeaten)
    {
        MoveCard = moveCard;

        if (actionTypeEnum == ActionTypeEnum.Attack)
        {
            _isBeaten = isBeaten;
        }

        if (actionTypeEnum == ActionTypeEnum.Defend)
        {
            _isTaken = isTaken;
        }

        if (moveCard == 0)
        {
            if (_isBeaten)
            {
                if (_firstPlayerCards != null)
                {
                    var v = _firstPlayerCards.ElementAt(moveCard);
                    _beatenCardIds.Add(v);
                    _firstPlayerCards.Remove(v);
                }

                var movesHistoryEntities = new MovesHistoryEntity();
                AddToDb(movesHistoryEntities);
            }
        }

        var playerHand = context.Hands;

        if (playerHand == null)
        {
            throw new KeyNotFoundException("player not found!");
        }

        var exitPlayer = playerHand.Any(p => p.PlayerId == playerId);

        if (!exitPlayer)
        {
            throw new Exception($"not card in hand player: {playerId}");
        }

        _firstPlayerCards = context.Hands.FirstOrDefault(h => h.PlayerId == playerId)?.CardIds.ToHashSet();

        if (_firstPlayerCards == null)
        {
            throw new Exception("this player doesn't have any card!");
        }

        var findCardWithIndex = _firstPlayerCards.ElementAt(moveCard);
        _movedCardIds.Add(findCardWithIndex);

        if (_isBeaten)
        {
            var v = _firstPlayerCards.ElementAt(moveCard);
            _firstPlayerCards.Remove(v);
            _beatenCardIds.Add(Convert.ToInt32(findCardWithIndex));

            var movesHistoryEntities = new MovesHistoryEntity();
            AddToDb(movesHistoryEntities);
        }

        void AddToDb(MovesHistoryEntity movesHistoryEntities)
        {
            MoveIdCounter++;
            movesHistoryEntities.PlayerId = playerId;
            movesHistoryEntities.Player = context.Players.FirstOrDefault(p => p.Id == playerId);
            movesHistoryEntities.IsBeaten = isBeaten;
            movesHistoryEntities.ActionType = actionTypeEnum;
            movesHistoryEntities.IsTaken = isTaken;
            movesHistoryEntities.MoveId = MoveIdCounter;
            movesHistoryEntities.MovedCardIds = _movedCardIds.ToHashSet();
            movesHistoryEntities.BeatenCardIds = _beatenCardIds.ToHashSet();
            context.MoveHistories.Add(movesHistoryEntities);
            context.SaveChanges();
        }

        var moveResponse = new MoveResponse()
        {
            MovedCardIds = _movedCardIds,
            ActionType = actionTypeEnum,
            PlayerId = playerId,
            IsBeaten = _isBeaten,
            IsTaken = _isTaken,
            BeatenCardIds = _beatenCardIds
        };

        var movesHistoryEntity = new MovesHistoryEntity
        {
            PlayerId = playerId,
            Player = context.Players.FirstOrDefault(p => p.Id == playerId),
            IsBeaten = _isBeaten,
            ActionType = actionTypeEnum,
            IsTaken = isTaken,
            MovedCardIds = _movedCardIds.ToHashSet(),
            BeatenCardIds = _beatenCardIds.ToHashSet()
        };

        AddToDb(movesHistoryEntity);

        return moveResponse;
    }

    public MoveResponse CreateMoveHistorySecondPlayer(ActionTypeEnum actionTypeEnum, long playerId,
        int moveCard, bool isTaken)
    {
        if (actionTypeEnum == ActionTypeEnum.Defend)
        {
            _isTaken = isTaken;
        }

        if (moveCard == 0)
        {
            throw new Exception("the card never should be 0!");
        }

        var playerHand = context.Hands;

        if (playerHand == null)
        {
            throw new KeyNotFoundException("player not found!");
        }

        var exitPlayer = playerHand.Any(p => p.PlayerId == playerId);

        if (!exitPlayer)
        {
            throw new Exception($"not card in hand player: {playerId}");
        }

        _secondPlayerCards = context.Hands.FirstOrDefault(h => h.PlayerId == playerId)?.CardIds.ToHashSet();

        if (_secondPlayerCards == null)
        {
            throw new Exception("this player doesn't have any card!");
        }

        var findCardWithIndex = _secondPlayerCards.ElementAt(moveCard);

        var cardIds = _secondPlayerCards;

        var cards = context.Cards.Where(p => cardIds.Contains(p.Id));
        var findCard = cards.FirstOrDefault(p => p.Id == findCardWithIndex);

        var newCardEntity =
            context.Cards.FirstOrDefault(
                p => _firstPlayerCards != null && p.Id == _firstPlayerCards.ElementAt(MoveCard)) ??
            throw new Exception("error");

        _movedCardIds.Add(findCardWithIndex);

        if (findCard != null && findCard.Suit == newCardEntity.Suit)
        {
            if (findCard.Rank < newCardEntity.Rank)
            {
                _beatenCardIds.Add(findCardWithIndex);
                _beatenCardIds.Add(newCardEntity.Id);
                if (!_isBeaten)
                {
                    var movesHistoryEntity = new MovesHistoryEntity
                    {
                        PlayerId = playerId,
                        Player = context.Players.FirstOrDefault(p => p.Id == playerId),
                        IsBeaten = _isBeaten,
                        ActionType = actionTypeEnum,
                        IsTaken = isTaken,
                        MovedCardIds = _movedCardIds.ToHashSet(),
                        BeatenCardIds = new()
                    };
                    AddToDb(movesHistoryEntity);
                }

                if (_isBeaten)
                {
                    var movesHistoryEntity1 = new MovesHistoryEntity
                    {
                        PlayerId = playerId,
                        Player = context.Players.FirstOrDefault(p => p.Id == playerId),
                        IsBeaten = _isBeaten,
                        ActionType = actionTypeEnum,
                        IsTaken = isTaken,
                        MovedCardIds = _movedCardIds.ToHashSet(),
                        BeatenCardIds = _beatenCardIds.ToHashSet()
                    };
                    AddToDb(movesHistoryEntity1);
                }
            }
            else
            {
                throw new Exception("this card can't  defend!");
            }
        }
        else
        {
            throw new Exception("this card can't  defend!");
        }


        if (_isBeaten)
        {
            _secondPlayerCards.RemoveWhere(e => e == moveCard);
            _beatenCardIds.Add(Convert.ToInt32(findCardWithIndex));

            var movesHistoryEntities = new MovesHistoryEntity();
            AddToDb(movesHistoryEntities);
        }

        if (isTaken)
        {
            if (_firstPlayerCards != null)
            {
                var takenCard = _firstPlayerCards.ElementAt(MoveCard);
                _secondPlayerCards.Add(takenCard);
            }
        }

        void AddToDb(MovesHistoryEntity movesHistoryEntity)
        {
            MoveIdCounter++;
            movesHistoryEntity.MoveId = MoveIdCounter;
            movesHistoryEntity.PlayerId = playerId;
            movesHistoryEntity.Player = context.Players.FirstOrDefault(p => p.Id == playerId);
            movesHistoryEntity.IsBeaten = _isBeaten;
            movesHistoryEntity.ActionType = actionTypeEnum;
            movesHistoryEntity.IsTaken = isTaken;
            movesHistoryEntity.MovedCardIds = _movedCardIds.ToHashSet();
            movesHistoryEntity.BeatenCardIds = [];
            context.MoveHistories.Add(movesHistoryEntity);
            context.SaveChanges();
        }

        var selectHandCadrs = context.Cards;
        var cardForDefend = selectHandCadrs.Where(p => p.Id == moveCard);

        var moveResponse = new MoveResponse()
        {
            MovedCardIds = _movedCardIds,
            ActionType = actionTypeEnum,
            PlayerId = playerId,
            IsBeaten = _isBeaten,
            IsTaken = _isTaken,
            BeatenCardIds = _beatenCardIds,
            MovedCard = cardForDefend
        };

        return moveResponse;
    }

    public HashSet<CardEntity> GetPFirstPlayerCards(long playerId)
    {
        var handEntity = context.Hands.FirstOrDefault(p => p.PlayerId == playerId) ??
                         throw new Exception("player doesn't exit!");
        var cardIds = handEntity.CardIds;

        var cards = context.Cards.Where(p => cardIds.Contains(p.Id));
        return cards.ToHashSet();
    }

    public HashSet<CardEntity> GetSecondPlayerCards(long playerId)
    {
        var handEntity = context.Hands.FirstOrDefault(p => p.PlayerId == playerId) ??
                         throw new Exception("player doesn't exit!");
        var cardIds = handEntity.CardIds;

        var cards = context.Cards.Where(p => cardIds.Contains(p.Id));
        return cards.ToHashSet();
    }
}