using System;

var date = new DateTime(25, 1, 2025);
var span1 = TimeSpan.FromHours(10);
var span2 = TimeSpan.FromSeconds(400);
var date2 = date + span1 + span2;