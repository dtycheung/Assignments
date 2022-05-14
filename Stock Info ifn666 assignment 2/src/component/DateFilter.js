
export function dataFiltering(userData, from, to) {
    let dates = [];
    let pclose = [];
    let popen = [];
    let phigh = [];
    let plow = [];
    let pvol = [];
    for (let key in userData) {
      dates.push(userData[key].date);
      pclose.push(userData[key].close);
      popen.push(userData[key].open);
      phigh.push(userData[key].high);
      plow.push(userData[key].low);
      pvol.push(userData[key].volume);
    }
    let indexStartDate = dates.indexOf(from);
    let indexEndDate = dates.indexOf(to);
    if (indexStartDate < 0) {
      indexStartDate = 0;
    }
    if (indexEndDate < 0) {
      indexEndDate = 99;
    }
  
    let filterDate = dates.slice(indexStartDate, indexEndDate + 1);
    let filterpclose = pclose.slice(indexStartDate, indexEndDate + 1);
    let filterpopen = popen.slice(indexStartDate, indexEndDate + 1);
  
    let filterphigh = phigh.slice(indexStartDate, indexEndDate + 1);
  
    let filterplow = plow.slice(indexStartDate, indexEndDate + 1);
    let filterpvol = pvol.slice(indexStartDate, indexEndDate + 1);
  
    let filterData = [];
    for (let e in filterDate) {
      filterData.push({
        date: filterDate[e],
        close: filterpclose[e],
        open: filterpopen[e],
        high: filterphigh[e],
        low: filterplow[e],
        volume: filterpvol[e],
      });
    }
    return filterData;
  }