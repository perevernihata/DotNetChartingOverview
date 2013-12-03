DotNetChartingOverview
=========

Overview  solutions for .NET Framework. Can be used for performance comparison of those charts


By default only free/open source charting solution are included to build. But most popular commercial solutions are also implemented. You can
easily check them with the next steps:
1. Open commercial solution from "/CommercialChartSolutions" directory.
2. Download and add missing assemblies (links to download are available there).
3. Build this solution.
4. Once you've done this, you should switch to "FreeChartTools" solution and uncomment appropriate lines in "SpringContext.xml".
(for example, if you've builded "DevExpressCharting" solution, you should uncomment  next lines:
........
                <!--<ref object="DevExpressFactory"/>-->
........
    <!--<object name="DevExpressFactory" type="DevExpressCharting.DevExpressChartFactory, DevExpressCharting, Version=1.0.0.0, Culture=neutral" singleton="false" />-->
........
)
5. Enjoy!