namespace StackOverflowSystem;

public interface IVotable
{
    void AddVote(Vote vote);
    int GetVoteCount();
}