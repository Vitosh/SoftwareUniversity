﻿function Solve(args) {
    var Ax = parseFloat(args[0]);
    var Ay = parseFloat(args[1]);
    var Bx = parseFloat(args[2]);
    var By = parseFloat(args[3]);
    var Cx = parseFloat(args[4]);
    var Cy = parseFloat(args[5]);

    var a = Math.sqrt(Math.pow(Bx - Ax, 2) + Math.pow(By - Ay, 2));
    var b = Math.sqrt(Math.pow(Cx - Bx, 2) + Math.pow(Cy - By, 2));
    var c = Math.sqrt(Math.pow(Cx - Ax, 2) + Math.pow(Cy - Ay, 2));

    var isTriangle = (a + b > c) && (b + c > a) && (a + c > b);

    if (isTriangle) {
        var p = (a + b + c) / 2;
        var area = Math.sqrt(p * (p - a) * (p - b) * (p - c));
        console.log("Yes");
        console.log(area.toFixed(2));
    } else {
        console.log("No");
        console.log(a.toFixed(2));
    }
}

Solve([2, 2, 0, 0, 1, 1]);
Solve([0, 2, 3, 0, -1, 4,]);