import { useState, useEffect } from "react";

const API_KEY = "9c7d78fa90084b4fa992460521743749";

async function getHeadlines(search) {
  const url = `https://newsapi.org/v2/top-headlines?country=au&apiKey=${API_KEY}&q= ${search}`;
  let res = await fetch(url);
  let date = await res.json();
  let articles = date.articles;
  return articles;
}

function getHeadlinesThen() {
  const url = `https://newsapi.org/v2/top-headlines?country=au&apiKey=${API_KEY}`;
  return fetch(url)
    .then((res) => res.json())
    .then((data) => data.articles);
}
export function useNewsArticle(search) {
  const [loading, setLoading] = useState(true);
  const [headlines, setHeadlines] = useState(true);
  const [error, setError] = useState(null);


  useEffect(() => {
    (async () => {
      try {
        setHeadlines(await getHeadlines(search));
        setLoading(false);
      } catch (err) {
        setError(err);
        setLoading(false);
      }
    })();
  }, [search]);
  /*
const headlines = [
    {title: "first", url: "http://google.com"},
    {title: "second", url: "http://facebook.com"}

  ];*/
  return {
    loading,
    headlines,
    error: null,
  };
}
