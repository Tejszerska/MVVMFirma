using MVVMFirma.Helper;
using MVVMFirma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region FirstAdditionalFeature

        #region Fields1
        // Contracts Menu
        private ICommand _AddCommand;
        private ICommand _ShowCommand;
        private ICommand _ShowPawnLoanOverviewCommand;
        private ICommand _ShowInterestRatesCommand;
        private ICommand _AddPurchaseContractCommand;
        private ICommand _ShowPurchaseContractCommand;
        private ICommand _AddPawnLoanCommand;
        private ICommand _ShowPawnLoanCommand;
        private ICommand _AddClientsCommand;
        private ICommand _ShowClientsCommand;


        // Network Menu
        private ICommand _ShowBranchesCommand;
        private ICommand _AddBranchesCommand;
        private ICommand _ShowEmployeesCommand;
        private ICommand _AddEmployeesCommand;
        private ICommand _ShowEmployeesShiftsCommand;

        #endregion

        #region Commands1
        // Contracts Menu
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => Add());
                }
                return _AddCommand;
            }
        }
        public ICommand ShowCommand
        {
            get
            {
                if (_ShowCommand == null)
                {
                    _ShowCommand = new BaseCommand(() => Show());
                }
                return _ShowCommand;
            }
        }
        public ICommand ShowPawnLoanOverviewCommand
        {
            get
            {
                if (_ShowPawnLoanOverviewCommand == null)
                {
                    _ShowPawnLoanOverviewCommand = new BaseCommand(() => ShowPawnLoanOverview());
                }
                return _ShowPawnLoanOverviewCommand;
            }
        }
        public ICommand ShowInterestRatesCommand
        {
            get
            {
                if (_ShowInterestRatesCommand == null)
                {
                    _ShowInterestRatesCommand = new BaseCommand(() => ShowInterestRates());
                }
                return _ShowInterestRatesCommand;
            }
        }
        public ICommand AddPurchaseContractCommand
        {
            get
            {
                if (_AddPurchaseContractCommand == null)
                {
                    _AddPurchaseContractCommand = new BaseCommand(() => AddPurchaseContract());
                }
                return _AddPurchaseContractCommand;
            }
        }
        public ICommand ShowPurchaseContractCommand
        {
            get
            {
                if (_ShowPurchaseContractCommand == null)
                {
                    _ShowPurchaseContractCommand = new BaseCommand(() => ShowPurchaseContract());
                }
                return _ShowPurchaseContractCommand;
            }
        }
        public ICommand AddPawnLoanCommand
        {
            get
            {
                if (_AddPawnLoanCommand == null)
                {
                    _AddPawnLoanCommand = new BaseCommand(() => AddPawnLoan());
                }
                return _AddPawnLoanCommand;
            }
        }
        public ICommand ShowPawnLoanCommand
        {
            get
            {
                if (_ShowPawnLoanCommand == null)
                {
                    _ShowPawnLoanCommand = new BaseCommand(() => ShowPawnLoan());
                }
                return _ShowPawnLoanCommand;
            }
        }
        public ICommand AddClientsCommand
        {
            get
            {
                if (_AddClientsCommand == null)
                {
                    _AddClientsCommand = new BaseCommand(() => AddClients());
                }
                return _AddClientsCommand;
            }
        }
        public ICommand ShowClientsCommand
        {
            get
            {
                if (_ShowClientsCommand == null)
                {
                    _ShowClientsCommand = new BaseCommand(() => ShowClients());
                }
                return _ShowClientsCommand;
            }
        }
        // Network Menu
        public ICommand ShowBranchesCommand
        {
            get
            {
                if (_ShowBranchesCommand == null)
                {
                    _ShowBranchesCommand = new BaseCommand(() => ShowBranches());
                }
                return _ShowBranchesCommand;
            }
        }
        public ICommand AddBranchesCommand
        {
            get
            {
                if (_AddBranchesCommand == null)
                {
                    _AddBranchesCommand = new BaseCommand(() => AddBranches());
                }
                return _AddBranchesCommand;
            }
        }
        public ICommand ShowEmployeesCommand
        {
            get
            {
                if (_ShowEmployeesCommand == null)
                {
                    _ShowEmployeesCommand = new BaseCommand(() => ShowEmployees());
                }
                return _ShowEmployeesCommand;
            }
        }
        public ICommand AddEmployeesCommand
        {
            get
            {
                if (_AddEmployeesCommand == null)
                {
                    _AddEmployeesCommand = new BaseCommand(() => AddEmployees());
                }
                return _AddEmployeesCommand;
            }
        }
        public ICommand ShowEmployeesShiftsCommand
        {
            get
            {
                if (_ShowEmployeesShiftsCommand == null)
                {
                    _ShowEmployeesShiftsCommand = new BaseCommand(() => ShowEmployeesShifts());
                }
                return _ShowEmployeesShiftsCommand;
            }
        }
        #endregion
        #region Helper1
        // Contracts Menu 
        private void Add()
        {
            this.CreateView(new NewBranchViewModel());
        }
        private void Show()
        {
            this.ShowAllView<AllBranchesViewModel>();
        }
        private void ShowPawnLoanOverview()
        {
            this.CreateView(new PawnLoansRaportViewModel());
          }
        private void ShowInterestRates()
        {
            this.ShowAllView<AllInterestRatesViewModel>();
        }
        private void AddPurchaseContract()
        {
            this.CreateView(new NewPurchaseContractViewModel());
        }
        private void ShowPurchaseContract()
        {
            this.ShowAllView<AllPurchaseContractsViewModel>();
        }
        private void AddPawnLoan()
        {
            this.CreateView(new NewPawnLoanViewModel());
        }
        private void ShowPawnLoan()
        {
            this.ShowAllView<AllPawnLoansViewModel>();
        }
        private void AddClients()
        {
            this.CreateView(new NewClientViewModel());
        }
        private void ShowClients()
        {
            this.ShowAllView<AllClientsViewModel>();
        }
        // Network Menu
        private void ShowBranches()
        {
            this.ShowAllView<AllBranchesViewModel>();
        }
        private void AddBranches()
        {
            this.CreateView(new NewBranchViewModel());
        }
        private void ShowEmployees()
        {
            this.ShowAllView<AllEmployeesViewModel>();
        }
        private void AddEmployees()
        {
            this.CreateView(new NewEmployeeViewModel());
        }
        private void ShowEmployeesShifts()
        {
            this.ShowAllView<AllEmployeeShiftsViewModel>();
        }
        #endregion
        #endregion

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
                    "-- LOGIKA BIZNESOWA -- ",
                    new BaseCommand(() => this.CreateView(null))),

                new CommandViewModel(
                    "Pawn Loans Overview ",
                    new BaseCommand(() => this.CreateView(new PawnLoansRaportViewModel()))),

                new CommandViewModel(
                    "Aging Inventory",
                    new BaseCommand(() => this.ShowAllView<InventoryAgingRaportViewModel>())),

                new CommandViewModel(
                    "Categories Statistics",
                    new BaseCommand(() => this.CreateView(new CategoryStatsRaportViewModel()))),


                new CommandViewModel(
                    "-- BEZ FK -- ",
                    new BaseCommand(() => this.CreateView(null))),
                 

                // proba z branches 
                new CommandViewModel(
                    "Branches",
                    new BaseCommand(() => this.ShowAllView<AllBranchesViewModel>())),

                new CommandViewModel(
                    "New Branch",
                    new BaseCommand(() => this.CreateView(new NewBranchViewModel()))),

                new CommandViewModel(
                    "Employees",
                    new BaseCommand(() => this.ShowAllView<AllEmployeesViewModel>())),

                new CommandViewModel(
                    "New employee",
                    new BaseCommand(() => this.CreateView(new NewEmployeeViewModel()))),

                new CommandViewModel(
                    "Interest Rates",
                    new BaseCommand(() => this.ShowAllView<AllInterestRatesViewModel>())),

                new CommandViewModel(
                    "New Interest Rate",
                    new BaseCommand(() => this.CreateView(new NewInterestRateViewModel()))),


                 new CommandViewModel(
                    "-- Z FK --",
                    new BaseCommand(() => this.CreateView(null))),

                new CommandViewModel(
                    "Clients",
                    new BaseCommand(() => this.ShowAllView<AllClientsViewModel>())),

                new CommandViewModel(
                    "New client",
                    new BaseCommand(() => this.CreateView(new NewClientViewModel()))),

                new CommandViewModel(
                    "Categories",
                    new BaseCommand(() => this.ShowAllView<AllCategoriesViewModel>())),

                new CommandViewModel(
                    "New Category",
                    new BaseCommand(() => this.CreateView(new NewCategoryViewModel()))),

                new CommandViewModel(
                    "Items",
                    new BaseCommand(() => this.ShowAllView<AllItemsViewModel>())),

               new CommandViewModel(
                    "New Item",
                    new BaseCommand(() => this.CreateView(new NewItemViewModel()))),

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

                new CommandViewModel(
                    "Records History",        
                    new BaseCommand(() => this.ShowAllView<RecordsHistoryViewModel>())),
                              
                new CommandViewModel(
                    "Employees Shifts",
                    new BaseCommand(() => this.ShowAllView<AllEmployeeShiftsViewModel>())),

                new CommandViewModel(
                    "-- TABELA ŁĄCZĄCA --",
                    new BaseCommand(() => this.CreateView(null))),

                new CommandViewModel(
                    "Purchase Contacts ",
                    new BaseCommand(() => this.ShowAllView<AllPurchaseContractsViewModel>())),

                new CommandViewModel(
                    "New Purchase Contract",
                    new BaseCommand(() => this.CreateView(new NewPurchaseContractViewModel()))),

                new CommandViewModel(
                    "Purchase Contract Items",
                    new BaseCommand(() => this.ShowAllView<AllPurchaseContractItemsViewModel>())),

                new CommandViewModel(
                    "New Purchase Contract Item",
                    new BaseCommand(() => this.CreateView(new NewPurchaseContractItemViewModel()))),

                new CommandViewModel(
                    "Pawn Loan Contracts",
                    new BaseCommand(() => this.ShowAllView<AllPawnLoansViewModel>())),

                new CommandViewModel(
                    "New Pawn Loan",
                    new BaseCommand(() => this.CreateView(new NewPawnLoanViewModel()))),

                new CommandViewModel(
                    "Pawn Loan Items",
                    new BaseCommand(() => this.ShowAllView<AllPawnLoanItemsViewModel>())),

                new CommandViewModel(
                    "New Pawn Loan Item",
                    new BaseCommand(() => this.CreateView(new NewPawnLoanItemViewModel()))),

                new CommandViewModel(
                    "Sales",
                    new BaseCommand(() => this.ShowAllView<AllSalesViewModel>())),

                new CommandViewModel(
                    "New Sale",
                    new BaseCommand(() => this.CreateView(new NewSaleViewModel()))),

                new CommandViewModel(
                    "Sales Items",
                    new BaseCommand(() => this.ShowAllView<AllSalesItemsViewModel>())),

              new CommandViewModel(
                    "New Sales Item",
                    new BaseCommand(() => this.CreateView(new NewSalesItemsViewModel()))),
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
            //workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        #endregion 

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
