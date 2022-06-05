using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vault_TecSettlerManager.Models;

namespace Vault_TecSettlerManager.UserControls
{
    /// <summary>
    /// Interaction logic for SpecialStatControl.xaml
    /// </summary>
    public partial class SpecialStatControl : UserControl
    {
        #region Dependency Properties
        public static readonly DependencyProperty SpecialLetterProperty =
            DependencyProperty.Register("SpecialLetter", typeof(string), typeof(SpecialStatControl), new PropertyMetadata("S"));
        
        public string SpecialLetter
        {
            get { return (string)GetValue(SpecialLetterProperty); }
            set { SetValue(SpecialLetterProperty, value); }
        }

        public static readonly DependencyProperty SpecialIconKindProperty =
            DependencyProperty.Register("SpecialIconKind", typeof(PackIconKind), typeof(SpecialStatControl), new PropertyMetadata(PackIconKind.ArmFlex));

        public PackIconKind SpecialIconKind
        {
            get { return (PackIconKind)GetValue(SpecialIconKindProperty); }
            set { SetValue(SpecialIconKindProperty, value); }
        }

        public static readonly DependencyProperty CurrentModiferProperty =
            DependencyProperty.Register("CurrentModifer", typeof(int), typeof(SpecialStatControl), new PropertyMetadata(0));

        public int CurrentModifer
        {
            get { return (int)GetValue(CurrentModiferProperty); }
            set { SetValue(CurrentModiferProperty, value); }
        }

        public static readonly DependencyProperty CurrentValueProperty =
            DependencyProperty.Register("CurrentValue", typeof(int), typeof(SpecialStatControl), new PropertyMetadata(0));

        public int CurrentValue
        {
            get { return (int)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }
        #endregion

        private readonly List<Buff>? _buffs;
        private int baseValue;
        private bool IsBuffed;

        public List<Buff> Buffs
        {
            get => _buffs ?? (new());
        }

        public SpecialStatControl()
        {
            InitializeComponent();
            baseValue = CurrentValue;
        }

        public bool addBuff(Buff b) {            
            Buffs.Add(b);
            return Buffs.Contains(b);
        }

        public bool removeBuff(Buff b) => Buffs.Remove(b);

        public int ComputeBuffs()
        {
            if (IsBuffed) {
                CurrentValue = baseValue;
                IsBuffed = false;
            }

            if (Buffs == null || Buffs.Count == 0) {
                return CurrentValue;
            }

            baseValue = CurrentValue;
            CurrentValue += Buffs.Sum(buff => buff.ValueModifier);
            IsBuffed = true;
            return CurrentValue;
        }
    }
}
