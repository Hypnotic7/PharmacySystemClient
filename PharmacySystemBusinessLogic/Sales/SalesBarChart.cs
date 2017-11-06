
namespace PharmacySystemBusinessLogic.Sales
{
    /*using org.jfree.chart.ChartFactory;
    using org.jfree.chart.ChartUtilities;
    using org.jfree.chart.JFreeChart;
    using org.jfree.chart.plot.PlotOrientation;
    using Dorg.jfree.data.category.DefaultCategoryDataset;

    public class SalesBarChart : IObserver
    {
        int latestMedicalCardSales = 0;
        int latestDrugSchemeSales = 0;
        int latestRegularSales = 0;

        ISubject salesDetails; // Subject reference variable

        // Note how subject is passed in the constructor of Observer
        public SalesBarChart(ISubject subject)
        {
            salesDetails = subject;
            salesDetails.Register(this); // Registering itself to the Subject
        }

        public void Update(int value, int value2, int value3)
        {
            latestMedicalCardSales = value;
            latestDrugSchemeSales = value2;
            latestRegularSales = value3;
            try
            {
                createBarChartImage(latestMedicalCardSales, latestDrugSchemeSales, latestRegularSales);
            }
            catch (IOException ex)
            {
                Logger.getLogger(typeof(SalesBarChart).FullName).log(Level.SEVERE, null, ex);
            }
        }

        public void CreateBarChartImage(int x, int y, int z)
        {

            const string perscription = "Sales involving Medical Card";
            const string drugScheme = "Sales involving Drug Scheme";
            const string regular = "Regular Sales";
            const string sales = "Sales";

            DefaultCategoryDataset dataset = new DefaultCategoryDataset();

            dataset.addValue(x, perscription, sales);
            dataset.addValue(y, drugScheme, sales);
            dataset.addValue(z, regular, sales);
            JFreeChart barChart = ChartFactory.createBarChart("Sales Report", "Category", "Number of Sales", dataset, PlotOrientation.VERTICAL, true, true, false);

            int width = 352; // Width of the image
            int height = 264; // Height of the image
            File BarChart = new File("BarChart.jpeg");
            ChartUtilities.saveChartAsJPEG(BarChart, barChart, width, height);
        }

        public string GetPieChartImage()
        {
            return "BarChart.jpeg";
        }

        public void Unsubscribe()
        {
            salesDetails.Unregister(this);
        }
    }*/
}