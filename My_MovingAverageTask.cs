using System.Collections.Generic;

namespace yield
{ //������� ����������� ��������.
  //��� ���������� � ����� ������� W,
  //������ W-1 ����� ���������� � ���������������� ������ ����������� 
  //�� ����� �������� �������.
  //���, ������ ����� ������ ������� � ��������� ��� ���������.

    public static class My_MovingAverageTask
    {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
        {
            var window = new Queue<double>();
            double sum = 0.0;
            foreach (var point in data)
            {
                if (windowWidth <= window.Count) sum -= window.Dequeue();
                window.Enqueue(point.OriginalY);
                sum += point.OriginalY;
                point.AvgSmoothedY = sum / window.Count;
                yield return point;
            }
        }
    }
}