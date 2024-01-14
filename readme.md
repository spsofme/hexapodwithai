## Gereksinimler
- python ● 3.8.10
- Unity ● 2022.3.4f1

## Kurulum
1. pip ile gerekli kütüphaneler kurulur.
```bash
cd hexapodwithai
pip install virtualenv
python -m venv myenv
./myenv/Scripts/activate
pip install -r requirements.txt
```

2. Unity paketlerini kurmak için Packages içinden manifest.json dosyası kullanılarak kurulum yapılır.

## Kullanım
1. virtualenv'e bağlantı kurulmadıysa proje ana diznine girilip `myenv/Scripts/activate` komutu çalıştırılır.
2. Unity'de proje açılır.
3. `mlagents-learn --run-id=<id_name> [--resume | --force]` komutu ile eğitim başlatılır.
4. Konsolda port dinleme aktif olduğunda Unity'de play tuşuna basılır.
