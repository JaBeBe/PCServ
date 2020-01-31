import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RegComponent } from '../reg/reg.component';

describe('RegisterComponent', () => {
  let comp: RegComponent;
  let fixture: ComponentFixture<RegComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        RegComponent
      ],
      imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule
      ]
    }).compileComponents().then(() => {
      fixture = TestBed.createComponent(RegComponent);

      comp = fixture.componentInstance;
    });
  }));


  it(`should set submitted to true`, async(() => {
    comp.onSubmit();
    expect(comp.submitted).toBeTruthy();
  }));

  it(`empty form should be invalid`, async(() => {
    comp.contactForm.controls['login'].setValue('');
    comp.contactForm.controls['password'].setValue('');
    expect(comp.contactForm.valid).toBeFalsy();
  }));

  it(`filled form should be valid`, async(() => {
    comp.contactForm.controls['login'].setValue('DefaultLogin');
    comp.contactForm.controls['password'].setValue('DefaultPassword');
    expect(comp.contactForm.valid).toBeTruthy();
  }));
});
