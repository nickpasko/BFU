var
  inp: text;
  fName: string;
  a: array [1..15] of real;
  difference, average: real;
  i, duration, preDuration: integer;

begin
  write('Имя файла: ');
  read(fName);
  if not ((pos('.tsv', fName) <> 0) and (pos('.tsv', fName) + 3 = Length(fName))) then
    fName := fName + '.tsv';
  Assign(inp, fName);
  Reset(inp);
  
  duration := 1;
  difference := 0; 
  average := 0; 
  for i := 1 to 14 do 
  begin
    read(inp, a[i]);
    average := average + a[i];
    if (i <> 1) then
    begin
      if (a[i] - a[i - 1] <> 0) then
      begin
        preDuration := duration;
        duration := 1;
        difference := a[i] - a[i-1];
      end
      else
      begin
        inc(duration);
      end;
    end;
  end;
  
  Randomize;
  if (duration < preDuration) then 
    a[15] := a[14]
  else if (duration = preDuration) then
    a[15] := a[14] + difference
  else if (duration > preDuration) and (random + (duration - preDuration)*0.1 > 0.85) then
    a[15] := a[14] + difference
  else
    a[15] := a[14]; 
  
  average := average + a[15];
  writeln('Прогноз: ', a[15]);
  writeln('Средняя: ', (average / 15):5:2);
  Write('Нажмите любую клавишу...');
  readln; readln;
end.