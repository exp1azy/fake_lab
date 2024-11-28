namespace FakeLab
{
    internal class GeneratorFactory
    {
        private readonly DateGenerator _dateGenerator;
        private readonly NumberGenerator _numberGenerator;
        private readonly TextGenerator _textGenerator;
        private readonly FlagGenerator _flagGenerator;

        internal GeneratorFactory(Random random)
        {
            _dateGenerator = new DateGenerator(random);
            _numberGenerator = new NumberGenerator(random);
            _textGenerator = new TextGenerator(random);
            _flagGenerator = new FlagGenerator(random);
        }

        internal DateGenerator DateGenerator => _dateGenerator;       
        internal NumberGenerator NumberGenerator => _numberGenerator;
        internal TextGenerator TextGenerator => _textGenerator;
        internal FlagGenerator FlagGenerator => _flagGenerator;
    }
}
