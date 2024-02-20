using experiment_test.Data.Entityes;
using experiment_test.Interfeces;
using experiment_test.Servises;
using Moq;

namespace TestServiseProject

{
    public class TestServises
    {
        private readonly Mock<IResultRepository> _resultRepositoryMock = new Mock<IResultRepository>();
        private readonly Mock<IExperimetRepository> _experimetRepositoryMock = new Mock<IExperimetRepository>();
        private readonly Mock<IDeviseRepository> _deviseRepositoryMock = new Mock<IDeviseRepository>();
        private async Task<List<Experiment>> GetALLTestExperimentAsync()
        {
            List<Experiment> experimentList = new()
            {
                new Experiment {Id=1, Name = "PRICE", StartExp = DateTime.Today, ExperimentOptions =
                {
                        new ExperimentOption { Id = 1, ExperimentId = 1, Percent= 33 , Value = "#FFOOOO"},
                        new ExperimentOption { Id = 2, ExperimentId = 1, Percent= 33 , Value = "#FFOOOO"},
                        new ExperimentOption { Id = 3, ExperimentId = 1, Percent= 33 , Value = "#FFOOOO"}
                }},
                new Experiment { Id = 2, Name = "COLOR", StartExp = DateTime.Today, ExperimentOptions =
                {
                      new ExperimentOption { Id = 4, ExperimentId = 2, Percent= 75, Value = "10"},
                      new ExperimentOption { Id = 5, ExperimentId = 2, Percent= 10 , Value = "20"},
                      new ExperimentOption { Id = 6, ExperimentId = 2, Percent= 5 , Value = "50"},
                      new ExperimentOption { Id = 7, ExperimentId = 2, Percent= 10 , Value = "10"}
                }}
            };

            return experimentList;
        }
        private async Task<List<Experiment>> GetALLTestExperimentAsync_Null()
        {
            List<Experiment>? experimentList = null;
            return experimentList;
        }


        [Fact]
        public async Task GetListExperimentAsync_IsNotNull_ShouldCallGetListExperimentAsync()
        {
            // Arrange
            _experimetRepositoryMock.Setup(x => x.GetListExperimentAsync()).Returns(GetALLTestExperimentAsync());
            var experimentServise = new ExperimentServise (_experimetRepositoryMock.Object, _deviseRepositoryMock.Object, _resultRepositoryMock.Object);

            // Act
            var result = await experimentServise.GetListExperimentAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Experiment>>(result);

        }
        [Fact]
        public async Task GetListExperimentAsync_IsNull_ShouldCallGetListExperimentAsync()
        {
            // Arrange
            _experimetRepositoryMock.Setup(x => x.GetListExperimentAsync()).Returns(GetALLTestExperimentAsync_Null());
            var experimentServise = new ExperimentServise(_experimetRepositoryMock.Object, _deviseRepositoryMock.Object, _resultRepositoryMock.Object);

            // Act
            var result = await experimentServise.GetListExperimentAsync();

            // Assert
            Assert.Null(result);

        }

        [Fact]
        public async Task AddNewDeviseAsync_IsNotNull_ShouldNotCallAddNewDeviseAsync()
        {
            // Arrange

            var experimentServise = new ExperimentServise(_experimetRepositoryMock.Object, _deviseRepositoryMock.Object, _resultRepositoryMock.Object);
            Devise? devise = new() {Id=1, FirstRequst = DateTime.Now, Token = "8445411" };

            // Act
            await experimentServise.AddNewDeviseAsync(devise);

            // Assert
            _deviseRepositoryMock.Verify(x => x.AddNewDeviseAsync(It.IsAny<Devise>()), Times.Once);
        }
        [Fact]
        public async Task AddResultAsync_IsNotNull_ShouldNotCallAddResultAsync()
        {
            // Arrange

            var experimentServise = new ExperimentServise(_experimetRepositoryMock.Object, _deviseRepositoryMock.Object, _resultRepositoryMock.Object);
            Result result = new() { Id = 5, DeviseId = 1, result = "50", ExperimentId = 1};

            // Act
            await experimentServise.AddResultAsync(result);

            // Assert
            _resultRepositoryMock.Verify(x => x.AddResultAsync(It.IsAny<Result>()), Times.Once);
        }

        [Fact]
        public async Task DoExperimentAsycNotNull_ShouldNotCallDoExperimentAsyc()
        {
            // Arrange

            var experimentServise = new ExperimentServise(_experimetRepositoryMock.Object, _deviseRepositoryMock.Object, _resultRepositoryMock.Object);
            var experiment = new Experiment
            {
                Id = 1,
                Name = "PRICE",
                StartExp = DateTime.Today,
                ExperimentOptions =
                {
                        new ExperimentOption { Id = 1, ExperimentId = 1, Percent= 33 , Value = "#FFOOOO"},
                        new ExperimentOption { Id = 2, ExperimentId = 1, Percent= 33 , Value = "#FFOOOO"},
                        new ExperimentOption { Id = 3, ExperimentId = 1, Percent= 33 , Value = "#FFOOOO"}
                }
            };
            Devise? devise = new() { Id = 1, FirstRequst = DateTime.Now, Token = "8445411" };

            // Act
            await experimentServise.DoExperimentAsyc(experiment,devise);

            // Assert
            _resultRepositoryMock.Verify(x => x.AddResultAsync(It.IsAny<Result>()), Times.Once);
        }
    }
}