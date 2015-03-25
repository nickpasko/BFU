program Project_vs;

{$APPTYPE CONSOLE}
 {Порограмма принимает на вход имя двух бойцов,
  урон и количесвто здоровья
 пример входа
 2 шварц 10 100 вандамм 70 20}
uses
  SysUtils;

var
  n, damage_1,damage_2,hp_1, hp_2, hit, count,i: integer;
  name_1, name_2,s,s1: string;


begin
  Assign(Input, 'input.txt');
  Reset(Input);
  Assign(Output, 'output.txt');
  Rewrite(Output);
  name_1:='';
  name_2:='';
  count:=1;
  read(s);
  i:=1;
  n:=length(s);
  while i<=n do begin
    if (s[i]=' ') and (count=1) then begin
     Delete(s,1,i);
     n:=n-i;
     i:=1;
     inc (count);
     continue;
    end;
    if (s[i]=' ') and (count=2) then begin
      name_1:=s;
      Delete(name_1,i,Length(s)-i+1);
      Delete(s,1,i);
      n:=n-i;
      i:=1;
      inc (count);
      Continue;
    end;
    if (s[i]=' ') and (count=3) then begin
      s1:=s;
      Delete(s1,i,Length(s)-i+1);
      damage_1:=StrToInt(s1);
      Delete(s,1,i);
      n:=n-i;
      i:=1;
      Inc(count);
      Continue;
    end;
    if (s[i]=' ') and (count=4) then begin
      s1:=s;
      Delete(s1,i,Length(s)-i+1);
      hp_1:=StrToInt(s1);
      Delete(s,1,i);
      n:=n-i;
      i:=1;
      Inc(count);
      Continue;
    end;
    if (s[i]=' ') and (count=5) then begin
      name_2:=s;
      Delete(name_2,i,Length(s)-i+1);
      Delete(s,1,i);
      n:=n-i;
      i:=1;
      Inc(count);
      Continue;
    end;
    if (s[i]=' ') and (count=6) then begin
      s1:=s;
      Delete(s1,i,Length(s)-i+1);
      damage_2:=StrToInt(s1);
      Delete(s,1,i);
      n:=n-i;
      i:=1;
      Inc(count);
      Continue;
    end;
    if (i=n) and (count=7) then begin
      s1:=s;
      Delete(s1,i,Length(s)-i);
      hp_2:=StrToInt(s1);
      Delete(s,1,i);
      n:=n-i;
      i:=1;
      Inc(count);
      Continue;
    end;
    inc(i);
  end;
  Writeln(name_1,' ' , hp_1 ,' единиц здоровья ', name_2,' ' , hp_2, ' единиц здоровья');
  while (hp_1>0) and (hp_2>0) do begin
    hit:=random(damage_1+1);
    hp_2:=hp_2-hit;
    Writeln('Боец ',name_1,' бьёт бойца ', name_2,' на ', hit,' единиц здоровья!');
    hit:=random(damage_2+1);
    hp_1:=hp_1-hit;
    writeln ('Боец ',name_2,' бьёт бойца ', name_1,' на ', hit,' единиц здоровья!');
    Writeln(name_1,' ',  hp_1, ' единиц здоровья ', name_2,' ', hp_2, ' единиц здоровья');
  end;
  if hp_1<=0 then begin
   writeln(name_1,'  порван в клочья мощным ударом и лежит в луже собственной крови!');
   Writeln(name_2, ' победил!!!');
  end
  else begin
    writeln(name_2,'  порван в клочья мощным ударом и лежит в луже собственной крови!');
    Writeln(name_1, ' победил!!!');
  end;
end.
 