import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeklifAddComponent } from './teklif-add.component';

describe('TeklifAddComponent', () => {
  let component: TeklifAddComponent;
  let fixture: ComponentFixture<TeklifAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeklifAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeklifAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
