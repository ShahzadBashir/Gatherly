namespace Gatherly.Domain.Entities;

public class Gethering
{
    public Gethering(
        GatheringId id,
        Member creator,
        GatheringType type,
        DateTime scheduledAtUtc,
        string name,
        string? location
        )
    {
        GatheringId = id;
        Creator = creator;
        Type = type;
        ScheduledAtUtc = scheduledAtUtc;
        Name = name;
        Location = location;
    }
    public GatheringId GatheringId { get; private set; }
    public Member Creator { get; private set; }
    public GatheringType Type { get; private set; }
    public string Name { get; private set; }

    public DateTime ScheduledAtUtc { get; private set; }

    public string? Location { get;private set; }
    public int? MaximumNumberOfAttendees { get; private set; }
    public DateTime? InvitationExpiresAtUtc { get; private set; }

    public int NumberOfAttendees { get; private set; }
    List<Attendee> Attendees { get; set; }
    List<Invitation> Invitations { get; set; }
}
