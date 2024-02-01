using ProesBack.ViewModels;

namespace ProesBack.Interfaces
{
    public interface IAssignmentViewModelService
    {
        IEnumerable<AssignmentViewModel> GetAssignmentsByCourseId(long courseId);
        public AssignmentViewModel GetAssignmentById(long id);
        void CreateAssignment(AssignmentViewModel assignmentViewModel);
        void UpdateAssignment(AssignmentViewModel assignmentViewModel);
        void DeleteAssignment(long id);

    }
}
