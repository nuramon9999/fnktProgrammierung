module BankAccount

open System

type account =
    { mutable blc: decimal option
      superv: Object }

let mkBankAccount() =
    { superv = new Object()
      blc = None }

let openAccount (account: account) = { account with blc = Some 0.0M }

let closeAccount (account: account) = { account with blc = None }

let getBalance (account: account) = account.blc

let updateBalance change (account: account) =
    lock account.superv (fun () -> account.blc <- Some(account.blc.Value + change))
    account
