export interface IPaginated<T> {
    records: T[];
    total: number;
}