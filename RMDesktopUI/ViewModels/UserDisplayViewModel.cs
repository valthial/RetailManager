using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI.ViewModels
{
    public class UserDisplayViewModel : Screen
    {
        private readonly StatusInfoView _status;
        private readonly WindowManager _window;
        private readonly IUserEndpoint _userEndpoint;

        BindingList<UserModel> _users;

        public BindingList<UserModel> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }

        private UserModel _selectedUser;
          
        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set 
            { 
                _selectedUser = value;
                SelectedUserName = value.Email;
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        private string _selectedUserName;

        public string SelectedUserName
        {
            get 
            { 
                return _selectedUserName; 
            }
            set 
            {
                _selectedUserName = value;
                NotifyOfPropertyChange(() => SelectedUserName);
            }
        }


        public UserDisplayViewModel(StatusInfoView status,WindowManager window, IUserEndpoint userEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadUsers();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized Access", "You do not have permission to interact with the Sales Form.");
                    _window.ShowDialog(_status, null, settings);
                }
                else
                {
                    _status.UpdateMessage("Fatal Exception", ex.Message);
                    _window.ShowDialog(_status, null, settings);
                }

                TryClose();
            }
        }

        private async Task LoadUsers()
        {
            var userList = await _userEndpoint.GetAll();
            Users = new BindingList<UserModel>(userList);
        }
    }
}
