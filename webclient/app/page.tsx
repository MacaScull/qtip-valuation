'use client'

import StatsCard from "./components/StatsCard";
import TextBox from "./components/TextBox";
import { Suspense, useEffect, useState } from "react";
import { getStatCount } from "./lib/statCount";
import { postText } from "./lib/textPost";


export default function Home() {
  const [inputText, setInputText] = useState<string>("")
  const [count, setCount] = useState<number | null>(null);


  useEffect(() => {
    const fetchCount = async () => {
      try {
        const data = await getStatCount()
        setCount(data)
      } catch (err) {
        console.error("Failed to fetch count:", err)
      }
    }

    fetchCount()
  }, [])

  const handleSubmit = async () => {
    try {
      await postText(inputText)
      const updatedCount = await getStatCount()
      setCount(updatedCount)
      setInputText("") // optional: clear input after submit
    } catch (err) {
      console.error("Failed to submit text:", err)
    }
  }
  
  return (
    <div className="flex flex-col min-h-screen items-center justify-center space-y-6 bg-zinc-50 font-sans dark:bg-black">
      <Suspense fallback={<div>Loading...</div>}>
        <StatsCard title={"Total PII emails submitted:"} count={count} />
      </Suspense>
      <TextBox inputValue={inputText} handleChange={(e) => setInputText(e.target.value)} />
      <button className="btn" onClick={handleSubmit}>submit</button>
    </div>
  );
}
