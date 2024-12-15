using WpfApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class CommentViewModel : BindableBase
    {
        private readonly ICommentRepository _repository;

        public CommentViewModel(ICommentRepository repository)
        {
            _repository = repository;
            Comments = new ObservableCollection<Comments>();
            LoadComments();

            AddCommentCommand = new RelayCommand(OnAddComment);
            EditCommentCommand = new RelayCommand<Comments>(OnEditComment);
            ClearSearchInputCommand = new RelayCommand(OnClearSearch);
        }

        private ObservableCollection<Comments>? _comments;
        public ObservableCollection<Comments>? Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }

        private List<Comments>? _commentsList;
        public async void LoadComments()
        {
            _commentsList = await _repository.GetAllCommentsAsync();
            Comments = new ObservableCollection<Comments>(_commentsList);
        }

        private string? _searchInput;
        public string? SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterCommentsByMessage(_searchInput);
            }
        }

        private void FilterCommentsByMessage(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                Comments = new ObservableCollection<Comments>(_commentsList);
            }
            else
            {
                Comments = new ObservableCollection<Comments>(
                    _commentsList.Where(c => c.message.ToLower().Contains(searchText.ToLower())));
            }
        }

        public RelayCommand AddCommentCommand { get; private set; }
        public RelayCommand<Comments> EditCommentCommand { get; private set; }
        public RelayCommand ClearSearchInputCommand { get; private set; }

        public event Action AddCommentRequested = delegate { };
        public event Action<Comments> EditCommentRequested = delegate { };

        private void OnAddComment()
        {
            AddCommentRequested.Invoke();
        }

        private void OnEditComment(Comments comment)
        {
            EditCommentRequested.Invoke(comment);
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
