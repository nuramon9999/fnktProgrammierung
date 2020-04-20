module SpaceAge

type Planet(name: string, day: float) =
    member this.name = name

    member this.day = day * 31557600.0

let Mercury = Planet("Mercury", 0.2408467)
let Venus = Planet("Venus", 0.61519726)
let Earth = Planet("Earth", 1.0)
let Mars = Planet("Mars", 1.8808158)
let Jupiter = Planet("Jupiter", 11.862615)
let Saturn = Planet("Saturn", 29.447498)
let Uranus = Planet("Uranus", 84.016846)
let Neptune = Planet("Neptune", 164.79132)

let age (planet: Planet) (seconds: int64): float = float (seconds) / planet.day
