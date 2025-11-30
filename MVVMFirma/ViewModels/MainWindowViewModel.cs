using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MVVMFirma.Views;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {

                new CommandViewModel(
                    "Clients",
                    new BaseCommand(() => this.ShowAllView<AllClientsViewModel>())),

                new CommandViewModel(
                    "New client",
                    new BaseCommand(() => this.CreateView(new NewClientViewModel()))),

                new CommandViewModel(
                    "Pawn Loan Contracts",
                    new BaseCommand(() => this.ShowAllView<AllPawnLoansViewModel>())),

                new CommandViewModel(
                    "New Pawn Loan",
                    new BaseCommand(() => this.CreateView(new NewPawnLoanViewModel()))),

                new CommandViewModel(
                    "Pawn Loan Items",
                    new BaseCommand(() => this.ShowAllView<AllPawnLoanItemsViewModel>())),

//                new CommandViewModel(
//                    "New Pawn Loan Item",
//                    new BaseCommand(() => this.CreateView(new NewPawnLoanItemViewModel()))),

                new CommandViewModel(
                    "Interest Rates",
                    new BaseCommand(() => this.ShowAllView<AllInterestRatesViewModel>())),

                new CommandViewModel(
                    "New Interest Rate",
                    new BaseCommand(() => this.CreateView(new NewInterestRateViewModel()))),

                new CommandViewModel(
                    "Purchase Contacts ",
                    new BaseCommand(() => this.ShowAllView<AllPurchaseContractsViewModel>())),

                new CommandViewModel(
                    "New Purchase Contract",
                    new BaseCommand(() => this.CreateView(new NewPurchaseContractViewModel()))),

                new CommandViewModel(
                    "Purchase Contract Items",
                    new BaseCommand(() => this.ShowAllView<AllPurchaseContractItemsViewModel>())),

//                new CommandViewModel(
//                    "New Purchase Contract Item",
//                    new BaseCommand(() => this.CreateView(new NewPurchaseContractItemViewModel()))),

                new CommandViewModel(
                    "Categories",
                    new BaseCommand(() => this.ShowAllView<AllCategoriesViewModel>())),

                new CommandViewModel(
                    "New Category",
                    new BaseCommand(() => this.CreateView(new NewCategoryViewModel()))),

                new CommandViewModel(
                    "Items",
                    new BaseCommand(() => this.ShowAllView<AllItemsViewModel>())),

//                new CommandViewModel(
//                    "New Item",
//                    new BaseCommand(() => this.CreateView(new NewItemViewModel()))),

                new CommandViewModel(
                    "Sales",
                    new BaseCommand(() => this.ShowAllView<AllSalesViewModel>())),

                new CommandViewModel(
                    "New Sale",
                    new BaseCommand(() => this.CreateView(new NewSaleViewModel()))),

//                new CommandViewModel(
//                    "Sales Items",
//                    new BaseCommand(() => this.ShowAllView<AllSalesItemsViewModel>())),

//              new CommandViewModel(
//                    "New Sales Item",
//                    new BaseCommand(() => this.CreateView(new NewSalesItemsViewModel()))),

                new CommandViewModel(
                    "Payments",
                    new BaseCommand(() => this.ShowAllView<AllPaymentsViewModel>())),

                new CommandViewModel(
                    "New Payment",
                    new BaseCommand(() => this.CreateView(new NewPaymentViewModel()))),

                new CommandViewModel(
                    "Online Offers",
                    new BaseCommand(() => this.ShowAllView<AllOnlineSaleOffersViewModel>())),

                new CommandViewModel(
                    "New Online Offer",
                    new BaseCommand(() => this.CreateView(new NewOnlineSaleOfferViewModel()))),

                new CommandViewModel(
                    "Price History",
                    new BaseCommand(() => this.ShowAllView<AllPriceHistoryViewModel>())),

//                new CommandViewModel(
//                    "Single Price History",
//                    new BaseCommand(() => this.CreateView(new SinglePriceHistoryViewModel()))),

                new CommandViewModel(
                    "Records History",        
                    new BaseCommand(() => this.ShowAllView<RecordsHistoryViewModel>())),

                new CommandViewModel(
                    "Employees",
                    new BaseCommand(() => this.ShowAllView<AllEmployeesViewModel>())),

                new CommandViewModel(
                    "New employee",
                    new BaseCommand(() => this.CreateView(new NewEmployeeViewModel()))),

                new CommandViewModel(
                    "Employees Shifts",
                    new BaseCommand(() => this.ShowAllView<AllEmployeeShiftsViewModel>())),
                                
                new CommandViewModel(
                    "Branches",
                    new BaseCommand(() => this.ShowAllView<AllBranchesViewModel>())),

                new CommandViewModel(
                    "New Branch",
                    new BaseCommand(() => this.CreateView(new NewBranchViewModel()))),


            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllView<T>() where T : WorkspaceViewModel, new()
        {
            T workspace =
                this.Workspaces.FirstOrDefault(vm => vm is T)
                as T;
            if (workspace == null)
            {
                workspace = new T();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);

        }
        private void CreateTowar()
        {
            NowyTowarViewModel workspace = new NowyTowarViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllTowar()
        {
            WszystkieTowaryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel)
                as WszystkieTowaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
