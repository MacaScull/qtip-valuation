interface Statistics {
    title: string,
    count: number | null
}

export default function StatsCard({ title, count }: Statistics) {

    return (
        <div className="stats shadow">
            <div className="stat">
                <div className="stat-title">{title}</div>
                <div className="stat-value">{count ?? 0}</div>
            </div>
        </div>
    )
}