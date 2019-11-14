using DPINT_Wk2_Decorator.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DPINT_Wk2_Decorator.ViewModel
{
    public class FighterViewModel : ViewModelBase
    {
        private int _lives;
        public int Lives { get { return _lives; } set { _lives = value; RaisePropertyChanged("Lives"); } }

        private int _attackValue;
        public int AttackValue { get { return _attackValue; } set { _attackValue = value; RaisePropertyChanged("AttackValue"); } }

        private int _defenseValue;
        public int DefenseValue { get { return _defenseValue; } set { _defenseValue = value; RaisePropertyChanged("DefenseValue"); } }

        public ObservableCollection<FighterOptionsViewModel> OptionList { get; set; }
        private bool _canCreateFighter;
        public RelayCommand CreateFighterCommand { get; set; }
        public RelayCommand AttackCommand { get; set; }
        public ObservableCollection<string> FighterMessages { get; set; }

        private FighterFactory _fighterFactory; // Change this to test functionality changes -> FighterFactoryOriginal
        private IFighter _fighter;

        public FighterViewModel EnemyFighterViewModel { get; set; }

        #region Initialization
        public FighterViewModel()
        {
            CreateFighterCommand = new RelayCommand(CreateFighter, () => _canCreateFighter);
            AttackCommand = new RelayCommand(Attack);
            AttackValue = 15;
            DefenseValue = 4;
            Lives = 80;

            _fighterFactory = new FighterFactory(); // Change this to test functionality changes -> FighterFactoryOriginal

            FighterMessages = new ObservableCollection<string>();
            InitializeOptionList();

            _fighter = _fighterFactory.CreateFighter(Lives, AttackValue, DefenseValue, Enumerable.Empty<string>());
        }

        private void InitializeOptionList()
        {
            OptionList = new ObservableCollection<FighterOptionsViewModel>();

            foreach (var name in _fighterFactory.FighterOptions.Keys)
            {
                var description = _fighterFactory.FighterOptions[name];
                var optionsVM = new FighterOptionsViewModel(name, description);
                optionsVM.PropertyChanged += (obj, prop) =>
                {
                    if (prop.PropertyName == "Selected")
                    {
                        _canCreateFighter = true;
                        CreateFighterCommand.RaiseCanExecuteChanged();
                    }
                };
                OptionList.Add(optionsVM);
            }
        }
        #endregion Initialization

        private void CreateFighter()
        {
            var options = OptionList.Where(o => o.Selected).Select(o => o.Name);
            _fighter = _fighterFactory.CreateFighter(Lives, AttackValue, DefenseValue, options);

            AttackValue = _fighter.AttackValue;
            DefenseValue = _fighter.DefenseValue;

            _canCreateFighter = false;
            CreateFighterCommand.RaiseCanExecuteChanged();
        }

        public void Attack()
        {
            var attack = _fighter.Attack();
            LogMessages(attack.Messages);           

            if(EnemyFighterViewModel != null)
            {
                EnemyFighterViewModel.Defend(attack);
            }
        }
        
        private void Defend(Attack attack)
        {
            attack.Messages.Clear();
            _fighter.Defend(attack);
            AttackValue = _fighter.AttackValue;
            Lives = _fighter.Lives;
            DefenseValue = _fighter.DefenseValue;

            LogMessages(attack.Messages);
        }

        private void LogMessages(IList<string> messages)
        {
            foreach (var message in messages)
            {
                FighterMessages.Add(message);
            }
        }
    }
}
