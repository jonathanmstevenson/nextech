export interface IStory {
    id: number;
    by?: string;
    descendants: number;
    kids: number[];
    score: number;
    time: number;
    title?: string;
    type: string;   // The type of item. One of "job", "story", "comment", "poll", or "pollopt".
    url?: string;
}