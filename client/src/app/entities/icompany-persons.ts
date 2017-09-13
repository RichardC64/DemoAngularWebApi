export interface ICompanyPersons {
    id: number;
    name: string;
    totalCount: number;
    persons: {
        id: number;
        firstName: string;
        lastName: string;
    }[];
}
