namespace PharmacySystemBusinessLogic.Sales
{
    /*org.jfree.chart.ChartFactory;
	org.jfree.chart.ChartUtilities;
	org.jfree.chart.JFreeChart;
	org.jfree.data.general.DefaultPieDataset;

	public class SalesPieChart : IObserver
    {
        int latestMedicalCardSales = 0;
        int latestDrugSchemeSales = 0;
        int latestRegularSales = 0;

        ISubject salesDetails; // Subject reference variable

        // Note how subject is passed in the constructor of Observer
        public SalesPieChart(ISubject subject)
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
                createPieChartImage(latestMedicalCardSales, latestDrugSchemeSales, latestRegularSales);
            }
            catch (IOException ex)
            {
                Logger.getLogger(typeof(SalesPieChart).FullName).log(Level.SEVERE, null, ex);
            }
        }

        public void CreatePieChartImage(int x, int y, int z)
        {
            DefaultPieDataset dataset = new DefaultPieDataset();
            dataset.setValue("Sales involving Perscription", new double(x));
            dataset.setValue("Sales involving Drug Scheme", new double?(y));
            dataset.setValue("Reglar Sales", new double?(z));

            JFreeChart chart = ChartFactory.createPieChart("Sales Report", dataset, true, true, false);

            int width = 352; //image width
            int height = 264; //image height
            File pieChart = new File("PieChart.jpeg");
            ChartUtilities.saveChartAsJPEG(pieChart, chart, width, height);
        }

        public string GetPieChartImage()
        {
            return "PieChart.jpeg";
        }

        public void Unsubscribe()
        {
            salesDetails.Unregister(this);
        }
    }*/
}