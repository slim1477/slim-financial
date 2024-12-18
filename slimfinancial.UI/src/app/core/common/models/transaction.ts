

export interface Transaction{
    id: number,
    date : Date,
    description : string,
    credit : number,
    debit : number,
    balance: number
}