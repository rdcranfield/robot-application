using Microsoft.EntityFrameworkCore;

namespace robot_application_v1.DomainModelLayer.Contracts;

public interface IEntity
{
    public int Id { get; set; }
}