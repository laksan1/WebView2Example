import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KtdPlaygroundModule } from './playground/playground.module';
import { KtdRealLifeExampleModule } from './real-life-example/real-life-example.module';

const routes: Routes = [
    {
        path: '',
        redirectTo: 'playground',
        pathMatch: 'full'
    },
    {
        path: 'real-life-example',
        redirectTo: 'real-life-example',
        pathMatch: 'full'
    },
    {
        path: '**',
        redirectTo: 'playground'
    },
];

@NgModule({
    imports: [
        KtdPlaygroundModule,
        KtdRealLifeExampleModule,
        RouterModule.forRoot(routes, {
            enableTracing: false
        })],
    exports: [RouterModule]
})
export class KtdAppRoutingModule {}


