namespace _7COMm.Recrutamento.Application.WebUI.PagesModels
{
    public class JogoDaVelhaPageModel
    {
        public string[] Velha { get; set; } = new string[9];
        public bool TemVencedor { get; set; }


        #region Linha Zero Até a Coluna 2
        private string _linhaZeroColunaZero;
        public string LinhaZeroColunaZero
        {
            get
            {
                return _linhaZeroColunaZero;
            }
            set
            {
                _linhaZeroColunaZero = value;
                this.Velha[0] = value;
            }
        }
        private string _linhaZeroColunaUm;
        public string LinhaZeroColunaUm
        {
            get
            {
                return _linhaZeroColunaUm;
            }
            set
            {
                _linhaZeroColunaUm = value;
                this.Velha[1] = value;
            }
        }
        private string _linhaZeroColunaDois;
        public string LinhaZeroColunaDois
        {
            get
            {
                return _linhaZeroColunaDois;
            }
            set
            {
                _linhaZeroColunaDois = value;
                this.Velha[2] = value;
            }
        }
        #endregion

        #region Linha Um Até a Coluna 2
        private string _linhaUmColunaZero;
        public string LinhaUmColunaZero
        {
            get
            {
                return _linhaUmColunaZero;
            }
            set
            {
                _linhaUmColunaZero = value;
                this.Velha[3] = value;
            }
        }
        private string _linhaUmColunaUm;
        public string LinhaUmColunaUm
        {
            get
            {
                return _linhaUmColunaUm;
            }
            set
            {
                _linhaUmColunaUm = value;
                this.Velha[4] = value;
            }
        }
        private string _linhaUmColunaDois;
        public string LinhaUmColunaDois
        {
            get
            {
                return _linhaUmColunaDois;
            }
            set
            {
                _linhaUmColunaDois = value;
                this.Velha[5] = value;
            }
        }
        #endregion

        #region Linha Dois Até a Coluna 2
        private string _linhaDoisColunaZero;
        public string LinhaDoisColunaZero
        {
            get
            {
                return _linhaDoisColunaZero;
            }
            set
            {
                _linhaDoisColunaZero = value;
                this.Velha[6] = value;
            }
        }
        private string _linhaDoisColunaUm;
        public string LinhaDoisColunaUm
        {
            get
            {
                return _linhaDoisColunaUm;
            }
            set
            {
                _linhaDoisColunaUm = value;
                this.Velha[7] = value;
            }
        }
        private string _linhaDoisColunaDois;
        public string LinhaDoisColunaDois
        {
            get
            {
                return _linhaDoisColunaDois;
            }
            set
            {
                _linhaDoisColunaDois = value;
                this.Velha[8] = value;
            }
        }
        #endregion
    }
}
