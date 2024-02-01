using AutoMapper;
using ProesBack.Domain.Entities;
using ProesBack.Domain.Interfaces;
using ProesBack.Interfaces;
using ProesBack.ViewModels;

namespace ProesBack.Services
{
    public class AssignmentViewModelService : IAssignmentViewModelService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentViewModelService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public IEnumerable<AssignmentViewModel> GetAssignmentsByCourseId(long courseId)
        {
            var assignments = _assignmentRepository.GetByCourseId(courseId);
            return _mapper.Map<IEnumerable<AssignmentViewModel>>(assignments);
        }

        public AssignmentViewModel GetAssignmentById(long id)
        {
            var assignment = _assignmentRepository.Get(id);
            return _mapper.Map<AssignmentViewModel>(assignment);
        }

        public void CreateAssignment(AssignmentViewModel assignmentViewModel)
        {
            var assignment = _mapper.Map<Assignment>(assignmentViewModel);
            _assignmentRepository.Insert(assignment);
            _assignmentRepository.Save();
        }

        public void UpdateAssignment(AssignmentViewModel assignmentViewModel)
        {
            var assignment = _mapper.Map<Assignment>(assignmentViewModel);
            _assignmentRepository.Update(assignment.Id,assignment);
            _assignmentRepository.Save();
        }

        public void DeleteAssignment(long id)
        {
            _assignmentRepository.Delete(id);
            _assignmentRepository.Save();
        }
    }
}
