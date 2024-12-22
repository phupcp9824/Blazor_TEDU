using Blazor.Components;
using Blazor.Service;
using Blazored.Toast.Services;
using Data;
using Data.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Pages.BlazorIndex
{
    public partial class IndexTask
    {
        [Inject] private ITaskApiClient _taskApiClient { get; set; }
        [Inject] private IToastService _ItoastService { get; set; }

        private Guid deleteId { get; set; }
        protected Confirmation DeleteConfirmation { get; set; }
        private List<TaskDto> taskDtos;
        private TaskListSearch TaskListSearch = new TaskListSearch();
        private List<AssigneeDto> assigneeDtos;
        protected override async Task OnInitializedAsync()
        {
            taskDtos = await _taskApiClient.Get(TaskListSearch);
            assigneeDtos = await _taskApiClient.GetAssignee();
        }

        private async Task SearchFrom()
        {
            _ItoastService.ShowInfo("Search complete");
            taskDtos = await _taskApiClient.Get(TaskListSearch);

        }

        public void OnDeleteTask(Guid DeleteId)
        {
            deleteId = DeleteId;
            DeleteConfirmation.show();
        }

        public async Task OnConfirmDeleteTask(bool DeleteConfirm)
        {
            if (DeleteConfirm)
            {
                await _taskApiClient.DeleteTask(deleteId);
                taskDtos = await _taskApiClient.Get(TaskListSearch);
            }
        }

    }


}
