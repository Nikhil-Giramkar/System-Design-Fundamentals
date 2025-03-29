using System.Collections.ObjectModel;

namespace StackOverflowSystem;

public interface ICommentable
{
    void AddComment(Comment comment);
    ReadOnlyCollection<Comment> GetComments();
}