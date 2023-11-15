using HW2.Extensions;

int[,] matrix = (6, 7).GenerateMatrix();
matrix.Print();
matrix.Sort();
matrix.Print();


/*
    OUTPUT FOR matrix(3x3)
    4 3 5
    8 1 7
    2 9 6

    1 2 3
    4 5 6
    7 8 9

    OUTPUT FOR matrix(6x7)
    8 32 36 2 7 15 31
    35 17 34 40 42 23 18
    30 9 5 14 39 24 3
    4 19 1 38 10 13 33
    41 29 27 16 25 6 21
    11 28 20 22 37 26 12

    1 2 3 4 5 6 7
    8 9 10 11 12 13 14
    15 16 17 18 19 20 21
    22 23 24 25 26 27 28
    29 30 31 32 33 34 35
    36 37 38 39 40 41 42
*/
