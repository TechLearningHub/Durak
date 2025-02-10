using Durak.Contracts.Requests;
using Durak.Contracts.Responses;

namespace Durak.Application.Interfaces;

public interface IDeskService
{
    public DeskResponse AddDesk(DeskRequest request);
    public DeskResponse? GetDeskById(int deskId);
    public void DeleteDeskById(int deskId);
    public DeskResponse? UpdateDesk(int deskId, DeskRequest deskRequest);
}