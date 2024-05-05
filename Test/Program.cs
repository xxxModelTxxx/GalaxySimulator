using PhysicsEngine;

Space2D Space = new Space2D(10, 10);
//Space.GenerateStars(0.2f, 1.0f, 1.0f);
Space.AddStar(2, 5, 1.0f);
Space.AddStar(8, 5, 1.0f);

for (int i = 0; i<10; i++)
{
    Space.SimulationStepForward();
}

Console.ReadLine();
