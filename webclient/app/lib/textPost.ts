
export async function postText(text: string) {
    const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/Submissions/create`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json" 
        },
        body: JSON.stringify({textSubmission: text})
    })
    
    if (!res.ok) {
        throw new Error('Failed to fetch posts')
    }
    
    return res.json()
}
