// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Area Chart Example

var ctx1 = document.getElementById("TemAreaChart");
var tem1 = document.getElementById("Tem1").value;
var tem2 = document.getElementById("Tem2").value;
var tem3 = document.getElementById("Tem3").value;
var tem4 = document.getElementById("Tem4").value;
var tem5 = document.getElementById("Tem5").value;
var tem6 = document.getElementById("Tem6").value;
var tem7 = document.getElementById("Tem7").value;

var ctx2 = document.getElementById("HumAreaChart");
var hum1 = document.getElementById("Hum1").value;
var hum2 = document.getElementById("Hum2").value;
var hum3 = document.getElementById("Hum3").value;
var hum4 = document.getElementById("Hum4").value;
var hum5 = document.getElementById("Hum5").value;
var hum6 = document.getElementById("Hum6").value;
var hum7 = document.getElementById("Hum7").value;

var ctx3 = document.getElementById("PreAreaChart");
var pre1 = document.getElementById("Pre1").value;
var pre2 = document.getElementById("Pre2").value;
var pre3 = document.getElementById("Pre3").value;
var pre4 = document.getElementById("Pre4").value;
var pre5 = document.getElementById("Pre5").value;
var pre6 = document.getElementById("Pre6").value;
var pre7 = document.getElementById("Pre7").value;

var myLineChart1 = new Chart(ctx1, {
  type: 'line',
  data: {
      labels: ["Dia 1", "Dia 2", "Dia 3", "Dia 4", "Dia 5", "Dia 6", "Dia 7"],
    datasets: [{
      label: "Sessions",
      lineTension: 0.3,
      backgroundColor: "rgba(2,117,216,0.2)",
      borderColor: "rgba(2,117,216,1)",
      pointRadius: 5,
      pointBackgroundColor: "rgba(2,117,216,1)",
      pointBorderColor: "rgba(255,255,255,0.8)",
      pointHoverRadius: 5,
      pointHoverBackgroundColor: "rgba(2,117,216,1)",
      pointHitRadius: 50,
      pointBorderWidth: 2,
      data: [tem1,tem2,tem3,tem4,tem5,tem6,tem7],
    }],
  },
  options: {
    scales: {
      xAxes: [{
        time: {
          unit: 'date'
        },
        gridLines: {
          display: false
        },
        ticks: {
          maxTicksLimit: 7
        }
      }],
      yAxes: [{
        ticks: {
          min: 0,
          max: 100,
          maxTicksLimit: 5
        },
        gridLines: {
          color: "rgba(0, 0, 0, .125)",
        }
      }],
    },
    legend: {
      display: false
    }
  }
});


var myLineChart2 = new Chart(ctx2, {
  type: 'line',
  data: {
      labels: ["Dia 1", "Dia 2", "Dia 3", "Dia 4", "Dia 5", "Dia 6", "Dia 7"],
    datasets: [{
      label: "Sessions",
      lineTension: 0.3,
      backgroundColor: "rgba(2,117,216,0.2)",
      borderColor: "rgba(2,117,216,1)",
      pointRadius: 5,
      pointBackgroundColor: "rgba(2,117,216,1)",
      pointBorderColor: "rgba(255,255,255,0.8)",
      pointHoverRadius: 5,
      pointHoverBackgroundColor: "rgba(2,117,216,1)",
      pointHitRadius: 50,
      pointBorderWidth: 2,
      data: [hum1,hum2,hum3,hum4,hum5,hum6,hum7],
    }],
  },
  options: {
    scales: {
      xAxes: [{
        time: {
          unit: 'date'
        },
        gridLines: {
          display: false
        },
        ticks: {
          maxTicksLimit: 7
        }
      }],
      yAxes: [{
        ticks: {
          min: 0,
          max: 100,
          maxTicksLimit: 5
        },
        gridLines: {
          color: "rgba(0, 0, 0, .125)",
        }
      }],
    },
    legend: {
      display: false
    }
  }
});


var myLineChart3 = new Chart(ctx3, {
  type: 'line',
  data: {
      labels: ["Dia 1", "Dia 2", "Dia 3", "Dia 4", "Dia 5", "Dia 6", "Dia 7"],
    datasets: [{
      label: "Sessions",
      lineTension: 0.3,
      backgroundColor: "rgba(2,117,216,0.2)",
      borderColor: "rgba(2,117,216,1)",
      pointRadius: 5,
      pointBackgroundColor: "rgba(2,117,216,1)",
      pointBorderColor: "rgba(255,255,255,0.8)",
      pointHoverRadius: 5,
      pointHoverBackgroundColor: "rgba(2,117,216,1)",
      pointHitRadius: 50,
      pointBorderWidth: 2,
      data: [pre1, pre2, pre3, pre4, pre5, pre6,pre7],
    }],
  },
  options: {
    scales: {
      xAxes: [{
        time: {
          unit: 'date'
        },
        gridLines: {
          display: false
        },
        ticks: {
          maxTicksLimit: 7
        }
      }],
      yAxes: [{
        ticks: {
          min: 0,
          max: 100,
          maxTicksLimit: 5
        },
        gridLines: {
          color: "rgba(0, 0, 0, .125)",
        }
      }],
    },
    legend: {
      display: false
    }
  }
});