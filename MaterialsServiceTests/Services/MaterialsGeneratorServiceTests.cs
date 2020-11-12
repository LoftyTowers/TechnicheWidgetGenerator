using MaterialsService.Models;
using MaterialsService.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Reflection.Metadata.Ecma335;

namespace MaterialsServiceTests.Services
{
	[TestFixture]
	public class MaterialsGeneratorServiceTests
	{
		[SetUp]
		public void SetUp()
		{
			MockRepository = new MockRepository(MockBehavior.Strict);
			MockLogger = MockRepository.Create<ILogger<MaterialsGeneratorService>>(MockBehavior.Loose);
			MaterialGenService = new MaterialsGeneratorService(MockLogger.Object);
		}

		#region RectangleTests

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CreateRectangleMaterials_ReturnsCorrectBill()
		{
			// Arrange
			var widget = new RectangleWidget
			{
				XPosition = 10,
				YPosition = 10,
				Width = 30,
				Height = 40
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("Rectangle (10,10) width=30 height=40", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CheckRectangleErrorResponse_ReturnsErrorBill()
		{
			// Arrange

			// Act
			var result = MaterialGenService.CreateWidget<RectangleWidget>(null);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CheckRectangleForNegativeXPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new RectangleWidget
			{
				XPosition = -10,
				YPosition = 10,
				Width = 30,
				Height = 40
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CheckRectangleForNegativeYPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new RectangleWidget
			{
				XPosition = 10,
				YPosition = -10,
				Width = 30,
				Height = 40
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CheckRectangleForNegativeWidth_ReturnsErrorBill()
		{
			// Arrange
			var widget = new RectangleWidget
			{
				XPosition = 10,
				YPosition = 10,
				Width = -30,
				Height = 40
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CheckRectangleForNegativeHeight_ReturnsErrorBill()
		{
			// Arrange
			var widget = new RectangleWidget
			{
				XPosition = 10,
				YPosition = 10,
				Width = 30,
				Height = -40
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CheckRectangleForWidthIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new RectangleWidget
			{
				XPosition = 995,
				YPosition = 10,
				Width = 30,
				Height = 40
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("RectangleTests")]
		public void CreateWidget_CheckRectangleForHeightIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new RectangleWidget
			{
				XPosition = 10,
				YPosition = 910,
				Width = 30,
				Height = 140
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		#endregion

		#region SquareTests

		[Test]
		[Category("SquareTests")]
		public void CreateWidget_CreateSquareMaterials_ReturnsCorrectBill()
		{
			// Arrange
			var widget = new SquareWidget
			{
				XPosition = 15,
				YPosition = 30,
				Width = 35
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("Square (15,30) size=35", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("SquareTests")]
		public void CreateWidget_CheckSquareErrorResponse_ReturnsErrorBill()
		{
			// Arrange

			// Act
			var result = MaterialGenService.CreateWidget<SquareWidget>(null);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("SquareTests")]
		public void CreateWidget_CheckSquareForNegativeXPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new SquareWidget
			{
				XPosition = -15,
				YPosition = 30,
				Width = 35
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("SquareTests")]
		public void CreateWidget_CheckSquareForNegativeYPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new SquareWidget
			{
				XPosition = 15,
				YPosition = -30,
				Width = 35
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("SquareTests")]
		public void CreateWidget_CheckSquareForNegativeWidth_ReturnsErrorBill()
		{
			// Arrange
			var widget = new SquareWidget
			{
				XPosition = 15,
				YPosition = 30,
				Width = -35
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("SquareTests")]
		public void CreateWidget_CheckSquareForWidthIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new SquareWidget
			{
				XPosition = 995,
				YPosition = 30,
				Width = 35
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		#endregion

		#region EllipseTests

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CreateEllipseMaterials_ReturnsCorrectBill()
		{
			// Arrange
			var widget = new EllipseWidget
			{
				XPosition = 100,
				YPosition = 150,
				Width = 300,
				Height = 200
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("Ellipse (100,150) diameterH = 300 diameterV = 200", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CheckEllipseErrorResponse_ReturnsErrorBill()
		{
			// Arrange

			// Act
			var result = MaterialGenService.CreateWidget<EllipseWidget>(null);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CheckEllipseForNegativeXPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new EllipseWidget
			{
				XPosition = -100,
				YPosition = 150,
				Width = 300,
				Height = 200
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CheckEllipseForNegativeYPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new EllipseWidget
			{
				XPosition = 100,
				YPosition = -150,
				Width = 300,
				Height = 200
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CheckEllipseForNegativeWidth_ReturnsErrorBill()
		{
			// Arrange
			var widget = new EllipseWidget
			{
				XPosition = 100,
				YPosition = 150,
				Width = -300,
				Height = 200
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CheckEllipseForNegativeHeight_ReturnsErrorBill()
		{
			// Arrange
			var widget = new EllipseWidget
			{
				XPosition = 100,
				YPosition = 150,
				Width = 300,
				Height = -200
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CheckEllipseForWidthIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new EllipseWidget
			{
				XPosition = 900,
				YPosition = 150,
				Width = 300,
				Height = 200
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("EllipseTests")]
		public void CreateWidget_CheckEllipseForHeightIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new EllipseWidget
			{
				XPosition = 100,
				YPosition = 950,
				Width = 300,
				Height = 200
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		#endregion

		#region CircleTests

		[Test]
		[Category("CircleTests")]
		public void CreateWidget_CreateCircleMaterials_ReturnsCorrectBill()
		{
			// Arrange
			var widget = new CircleWidget
			{
				XPosition = 1,
				YPosition = 1,
				Width = 300
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("Circle (1,1) size=300", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("CircleTests")]
		public void CreateWidget_CheckCircleErrorResponse_ReturnsErrorBill()
		{
			// Arrange

			// Act
			var result = MaterialGenService.CreateWidget<CircleWidget>(null);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("CircleTests")]
		public void CreateWidget_CheckCircleForNegativeXPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new CircleWidget
			{
				XPosition = -1,
				YPosition = 1,
				Width = 300
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("CircleTests")]
		public void CreateWidget_CheckCircleForNegativeYPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new CircleWidget
			{
				XPosition = 1,
				YPosition = -1,
				Width = 300
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("CircleTests")]
		public void CreateWidget_CheckCircleForNegativeWidth_ReturnsErrorBill()
		{
			// Arrange
			var widget = new CircleWidget
			{
				XPosition = 1,
				YPosition = 1,
				Width = -300
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("CircleTests")]
		public void CreateWidget_CheckCircleForWidthIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new CircleWidget
			{
				XPosition = 911,
				YPosition = 1,
				Width = 300
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		#endregion

		#region TextboxTests

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CreateTextboxMaterials_ReturnsCorrectBill()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = 5,
				YPosition = 5,
				Width = 200,
				Height = 100,
				Text = "sample text"
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("Textbox (5,5) width=200 height=100 text=\"sample text\"", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxForNoText_ReturnsSuccessWithNoText()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = 5,
				YPosition = 5,
				Width = 200,
				Height = 100,
				Text = string.Empty
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("Textbox (5,5) width=200 height=100 text=\"\"", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxErrorResponse_ReturnsErrorBill()
		{
			// Arrange

			// Act
			var result = MaterialGenService.CreateWidget<TextboxWidget>(null);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxForNegativeXPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = -5,
				YPosition = 5,
				Width = 200,
				Height = 100,
				Text = "sample text"
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxForNegativeYPosition_ReturnsErrorBill()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = 5,
				YPosition = -5,
				Width = 200,
				Height = 100,
				Text = "sample text"
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxForNegativeWidth_ReturnsErrorBill()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = 5,
				YPosition = 5,
				Width = -200,
				Height = 100,
				Text = "sample text"
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxForNegativeHeight_ReturnsErrorBill()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = 5,
				YPosition = 5,
				Width = 200,
				Height = -100,
				Text = "sample text"
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxForWidthIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = 905,
				YPosition = 5,
				Width = 200,
				Height = 100,
				Text = "sample text"
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		[Test]
		[Category("TextboxTests")]
		public void CreateWidget_CheckTextboxForHeightIsInBounds_ReturnsErrorBill()
		{
			// Arrange
			var widget = new TextboxWidget
			{
				XPosition = 5,
				YPosition = 905,
				Width = 200,
				Height = 100,
				Text = "sample text"
			};

			// Act
			var result = MaterialGenService.CreateWidget(widget);

			// Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(string.IsNullOrWhiteSpace(result));
			Assert.AreEqual("+++++Abort+++++", result);
			MockRepository.VerifyAll();
		}

		#endregion

		#region Properties

		private MockRepository MockRepository { get; set; }
		public Mock<ILogger<MaterialsGeneratorService>> MockLogger { get; private set; }
		private MaterialsGeneratorService MaterialGenService { get; set; }

		#endregion
	}
}
