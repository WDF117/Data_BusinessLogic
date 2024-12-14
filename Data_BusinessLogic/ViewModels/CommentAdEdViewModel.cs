using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class CommentAdEdViewModel : BindableBase
    {
        private readonly ICommentRepository _repository;

        public CommentAdEdViewModel(ICommentRepository repository)
        {
            _repository = repository;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }
        private Comments _editingComment;
        private ValidableComment _comment;

        public ValidableComment Comment
        {
            get => _comment;
            set => SetProperty(ref _comment, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public event Action Done;

        internal void SetComment(Comments comment)
        {
            _editingComment = comment;
            Comment = new ValidableComment
            {
                message = comment.message,
                requestID = comment.requestID,
                masterID = comment.masterID
            };
        }
        private async void OnSave()
        {
            if (IsEditMode)
            {
                _editingComment.message = Comment.message;
                _editingComment.requestID = Comment.requestID;
                _editingComment.masterID = Comment.masterID;

                await _repository.UpdateCommentAsync(_editingComment);
            }
            else
            {
                var newComment = new Comments
                {
                    message = Comment.message,
                    requestID = Comment.requestID,
                    masterID = Comment.masterID
                };

                await _repository.AddCommentAsync(newComment);
            }

            Done?.Invoke();
        }
        private bool CanSave() => !Comment.HasErrors;
        internal void OnCancel()
        {
            Done?.Invoke();
        }
    }
}
