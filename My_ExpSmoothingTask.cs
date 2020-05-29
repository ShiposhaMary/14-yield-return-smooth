using System.Collections.Generic;

namespace yield
{  //Ёкспоненциальное сглаживание.
	public static class My_ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
            var isFirstItem = true;
            double previousItem = 0;
            foreach (var e in data)
            {
                var newDataPoint = new DataPoint();
                newDataPoint.AvgSmoothedY = e.AvgSmoothedY;
                newDataPoint.MaxY = e.MaxY;
                newDataPoint.OriginalY = e.OriginalY;
                newDataPoint.X = e.X;
                if (isFirstItem)
                {
                    isFirstItem = false;
                    previousItem = e.OriginalY;
                }
                else
                {
                    previousItem = alpha * e.OriginalY + (1 - alpha) * previousItem;
                }
                newDataPoint.ExpSmoothedY = previousItem;
                yield return newDataPoint;
            }
        }
	}
}