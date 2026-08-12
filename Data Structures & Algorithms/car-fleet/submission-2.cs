public class Solution {

    class Car {
        public int Position;
        public int Speed;
        public double TimeToTarget;
    }

    public int CarFleet(int target, int[] position, int[] speed) {
        
        int carsCount = position.Length;
        
        List<Car> carsSortedByTTT = [];

        for(int i=0; i < carsCount; i++) {
            carsSortedByTTT.Add(
                new Car() { 
                    Position = position[i],
                    Speed = speed[i],
                    TimeToTarget = ((double)target - position[i])/speed[i],
                }
            );
        }

        var carsComparer = Comparer<Car>.Create((Car c1, Car c2) => c2.Position.CompareTo(c1.Position));
        carsSortedByTTT.Sort(carsComparer);

        Stack<Car> cars = [];
        int fleetsCount = 0;
        foreach (var car in carsSortedByTTT) {
            if(cars.Count == 0) {
                cars.Push(car);
                fleetsCount++;
            } else {
                if(car.TimeToTarget <= cars.Peek().TimeToTarget) {
                    // This car joins the existing fleet
                } else {
                    // This car will not be able to catch-up the next-faster car in the stack
                    cars.Push(car);
                    fleetsCount++;
                }

            }
        }     

        return fleetsCount;
    }
}
