export function urlQuery(){
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    if(urlParams.has('symbol') &&urlParams.get('symbol')!==""){
        let urlquery = urlParams.get('symbol')
      return urlquery;
    }else return false;
  }