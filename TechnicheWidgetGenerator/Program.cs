using MaterialsService.Interfaces;
using MaterialsService.Models;
using MaterialsService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections;

namespace TechnicheWidgetGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);

			var serviceProvider = serviceCollection.BuildServiceProvider();

			var materialGenerator = serviceProvider.GetService<IMaterialsGeneratorService>();
			Log = serviceProvider.GetService<ILogger<Program>>();

			GenerateRectangles(materialGenerator);
			GenerateSquares(materialGenerator);
			GenerateEllipses(materialGenerator);
			GenerateCircles(materialGenerator);
			GenerateTextboxes(materialGenerator);
		}

		private static void GenerateRectangles(IMaterialsGeneratorService materialGenerator)
		{
			var rectangles = new List<RectangleWidget>()
			{
				new RectangleWidget
				{
					XPosition = 10,
					YPosition = 10,
					Width = 30,
					Height = 40
				},
				new RectangleWidget
				{
					XPosition = -10,
					YPosition = 10,
					Width = 30,
					Height = 40
				},
				new RectangleWidget
				{
					XPosition = 10,
					YPosition = -10,
					Width = 30,
					Height = 40
				},
				new RectangleWidget
				{
					XPosition = 10,
					YPosition = 10,
					Width = -30,
					Height = 40
				},
				new RectangleWidget
				{
					XPosition = 10,
					YPosition = 10,
					Width = 30,
					Height = -40
				},
				new RectangleWidget
				{
					XPosition = 995,
					YPosition = 10,
					Width = 30,
					Height = 40
				},
				new RectangleWidget
				{
					XPosition = 10,
					YPosition = 910,
					Width = 30,
					Height = 140
				}
			};

			foreach (var rect in rectangles)
			{
				Log.LogInformation(materialGenerator.CreateWidget(rect));
			}
		}

		private static void GenerateSquares(IMaterialsGeneratorService materialGenerator)
		{
			var squares = new List<SquareWidget>()
			{
				new SquareWidget
				{
					XPosition = 15,
					YPosition = 30,
					Width = 35
				},
				new SquareWidget
				{
					XPosition = -15,
					YPosition = 30,
					Width = 35
				},
				new SquareWidget
				{
					XPosition = 15,
					YPosition = -30,
					Width = 35
				},
				new SquareWidget
				{
					XPosition = 15,
					YPosition = 30,
					Width = -35
				},
				new SquareWidget
				{
					XPosition = 995,
					YPosition = 30,
					Width = 35
				}
			};

			foreach (var squ in squares)
			{
				Log.LogInformation(materialGenerator.CreateWidget(squ));
			}
		}

		private static void GenerateEllipses(IMaterialsGeneratorService materialGenerator)
		{
			var ellipses = new List<EllipseWidget>()
			{
				new EllipseWidget
				{
					XPosition = 100,
					YPosition = 150,
					Width = 300,
					Height = 200
				},
				new EllipseWidget
				{
					XPosition = -100,
					YPosition = 150,
					Width = 300,
					Height = 200
				},
				new EllipseWidget
				{
					XPosition = 100,
					YPosition = -150,
					Width = 300,
					Height = 200
				},
				new EllipseWidget
				{
					XPosition = 100,
					YPosition = 150,
					Width = -300,
					Height = 200
				},
				new EllipseWidget
				{
					XPosition = 100,
					YPosition = 150,
					Width = 300,
					Height = -200
				},
				new EllipseWidget
				{
					XPosition = 900,
					YPosition = 150,
					Width = 300,
					Height = 200
				},
				new EllipseWidget
				{
					XPosition = 100,
					YPosition = 950,
					Width = 300,
					Height = 200
				}
			};

			foreach (var elp in ellipses)
			{
				Log.LogInformation(materialGenerator.CreateWidget(elp));
			}
		}

		private static void GenerateCircles(IMaterialsGeneratorService materialGenerator)
		{
			var circles = new List<CircleWidget>()
			{
				new CircleWidget
				{
					XPosition = 1,
					YPosition = 1,
					Width = 300
				},
				new CircleWidget
				{
					XPosition = -1,
					YPosition = 1,
					Width = 300
				},
				new CircleWidget
				{
					XPosition = 1,
					YPosition = -1,
					Width = 300
				},
				new CircleWidget
				{
					XPosition = 1,
					YPosition = 1,
					Width = -300
				},
				new CircleWidget
				{
					XPosition = 911,
					YPosition = 1,
					Width = 300
				}
			};

			foreach (var circ in circles)
			{
				Log.LogInformation(materialGenerator.CreateWidget(circ));
			}
		}

		private static void GenerateTextboxes(IMaterialsGeneratorService materialGenerator)
		{
			var textboxes = new List<TextboxWidget>()
			{
				new TextboxWidget
				{
					XPosition = 5,
					YPosition = 5,
					Width = 200,
					Height = 100,
					Text = "sample text"
				},
				new TextboxWidget
				{
					XPosition = 5,
					YPosition = 5,
					Width = 200,
					Height = 100,
					Text = string.Empty
				},
				new TextboxWidget
				{
					XPosition = -5,
					YPosition = 5,
					Width = 200,
					Height = 100,
					Text = "sample text"
				},
				new TextboxWidget
				{
					XPosition = 5,
					YPosition = -5,
					Width = 200,
					Height = 100,
					Text = "sample text"
				},
				new TextboxWidget
				{
					XPosition = 5,
					YPosition = 5,
					Width = -200,
					Height = 100,
					Text = "sample text"
				},
				new TextboxWidget
				{
					XPosition = 5,
					YPosition = 5,
					Width = 200,
					Height = -100,
					Text = "sample text"
				},
				new TextboxWidget
				{
					XPosition = 905,
					YPosition = 5,
					Width = 200,
					Height = 100,
					Text = "sample text"
				},
				new TextboxWidget
				{
					XPosition = 5,
					YPosition = 905,
					Width = 200,
					Height = 100,
					Text = "sample text"
				}
			};

			foreach (var txt in textboxes)
			{
				Log.LogInformation(materialGenerator.CreateWidget(txt));
			}
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddLogging(configure => configure.AddConsole())
								 .AddTransient<IMaterialsGeneratorService, MaterialsGeneratorService>();
		}

		#region Properties

		public static ILogger<Program> Log { get; set; }

		#endregion
	}
}
