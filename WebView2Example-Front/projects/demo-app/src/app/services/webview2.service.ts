import { Injectable } from "@angular/core";
import { EventsEnum } from "../interfaces/events.enum";

import { Message } from "../interfaces/message.interface";

type T = Window & typeof globalThis;
// @ts-ignore
interface window extends T {
    chrome?: any;
    dispatchWebViewEvent?: Function;
}

@Injectable({
    providedIn: 'root'
  })

export class WebView2Service {

    window: window;
    eventCaptureElement: HTMLAnchorElement = document.createElement("a");

    constructor() {
        this.window = window;
        this.window.dispatchWebViewEvent = this.dispatchWebViewEvent.bind(this);
    }

    dispatchWebViewEvent(message: Message) {
        const event = message.event;
        if (event === undefined) return;

        const customEvent: CustomEvent = new CustomEvent(message.event, { detail: message.payload });
        this.eventCaptureElement.dispatchEvent(customEvent);
    };

    subscribeToWebView2Event(event: EventsEnum, handler: any) {
        if (event === undefined) return;

        this.eventCaptureElement.addEventListener(event, handler);
    }

    unsubscribeToWebView2Event(event: EventsEnum, handler: any) {
        if (event === undefined) return;

        this.eventCaptureElement.removeEventListener(event, handler);
    }

    postWebView2Message(event: EventsEnum, payload: object = {}) {
        if (event === undefined) return;

        const message: Message = {
            event: event,
            payload: payload
        };

        this.window.chrome?.webview?.postMessage(message);
    }

    isInWebViewContext() {
        return !!this.window.chrome?.webview;
    }
}
