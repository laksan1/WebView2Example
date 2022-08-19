import {Component} from '@angular/core';
import {MatIconRegistry} from '@angular/material/icon';
import {DomSanitizer} from '@angular/platform-browser';
import {ActivatedRoute, Router, RoutesRecognized} from '@angular/router';
import {EventsEnum} from './interfaces/events.enum';
import {WebView2Service} from './services/webview2.service';

export interface WindowSize {
    height: number;
    width: number;
}

const defaultTitle = 'Angular-Revit-WebView2';

@Component({
    selector: 'ktd-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class KtdAppComponent {
    title: string = defaultTitle;
    size: WindowSize = {
        width: 400,
        height: 600,
    };

    constructor(private matIconRegistry: MatIconRegistry, private domSanitizer: DomSanitizer, private router: Router, private readonly route: ActivatedRoute,
                private readonly wv2Service: WebView2Service) {
        this.matIconRegistry.addSvgIcon(
            `github`,
            this.domSanitizer.bypassSecurityTrustResourceUrl(`assets/logos/github.svg`)
        );

        this.router.events.subscribe((data) => {
            if (data instanceof RoutesRecognized) {
                this.title = data.state.root.firstChild?.data.title || defaultTitle;
            }
        });
    }

    resizeWindow() {
        this.wv2Service.postWebView2Message(EventsEnum.ResizeWindow, this.size);
    }

    close() {
        this.wv2Service.postWebView2Message(EventsEnum.Close);
    }
}
