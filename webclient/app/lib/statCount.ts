
export async function getStatCount() {
  const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/Submissions/count`)
  
  if (!res.ok) {
    throw new Error('Failed to fetch posts')
  }
  
  return res.json()
}
