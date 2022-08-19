import { EventsEnum } from "./events.enum"

export interface Message {
    event: EventsEnum
    payload: object
}
