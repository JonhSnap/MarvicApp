import React, { useEffect, useRef, useState } from "react";
import { CanvasJSChart } from "canvasjs-react-charts";
import {BASE_URL} from "../../util/constants";
import axios from "axios";
const BarChartArea = ({project}) => {
  const [datapoint, setDatapoint] = useState([]);
  var dataPoints = [];
  let ref =useRef(null)
useEffect(()=>{
  console.log(ref.current.exportChart())
},[])
  const dataP = async () => {
    await axios
      .get(
        `${BASE_URL}/api/Issue/StatisticIssueArchived?idProject=${project?.id}&dateStarted=${project?.dateStarted}&dateEnd=${project?.dateEnd}`
      )
      .then((res) => {
        setDatapoint(res.data);
      });
  };
  useEffect(() => {
    dataP();
  }, [project]);

  if (datapoint && datapoint.length > 0) {
    for (var i = 0; i < datapoint.length; i++) {
      dataPoints.push({
        x: new Date(datapoint[i].x),
        y: datapoint[i].y,
      });
    }
  }


  const options = {
    theme: "light2",
    title: {
      text: "Comparison of Exchange Rates - 2017",
    },
    subtitles: [
      {
        text: "GBP & USD to INR",
      },
    ],
    axisY: {
      prefix: "₹",
    },
    toolTip: {
      shared: true,
    },
    data: [
      {
        type: "area",
        name: "GBP",
        showInLegend: true,
        xValueFormatString: "MMM YYYY",
        yValueFormatString: "₹#,##0.##",
        dataPoints: dataPoints,
      },
    ],
  };

const handleExportChart=()=>{

}
  return (
    <div className="mt-[30px]">
      <h2 className="text-2xl font-bold text-blue-600">
        Chart area Year month day
      </h2>
      <CanvasJSChart ref={ref} options={options} />
      <button ref={ref} onClick={handleExportChart} id="exportChart">Export Chart</button>
    </div>
  );
};

export default BarChartArea;
